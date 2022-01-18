package com.example.iot.ui.home;

import static android.content.Context.MODE_PRIVATE;

import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AbsListView;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckedTextView;
import android.widget.CompoundButton;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.ToggleButton;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.widget.Toolbar;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProvider;

import com.android.volley.AuthFailureError;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.iot.R;
import com.example.iot.databinding.FragmentHomeBinding;
import com.example.iot.device.DeviceItem;
import com.example.iot.device.DeviceListAdapter;
import com.example.iot.network.HttpsTrustManager;
import com.example.iot.network.SerialListener;
import com.example.iot.network.SerialSocket;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.nio.ByteBuffer;
import java.util.ArrayList;
import java.util.Set;
import java.util.UUID;

public class HomeFragment extends Fragment implements AbsListView.OnItemClickListener, SerialListener {

    private static final int REQUEST_BLUETOOTH = 1;
    private static final String DELIMITER = "\r\n";
    private HomeViewModel homeViewModel;
    private FragmentHomeBinding binding;
    private AbsListView mListView;
    private ToggleButton scanDeviceBtn;
    private BluetoothAdapter bTAdapter;
    private ArrayList <DeviceItem>deviceItemList;
    private ArrayAdapter<DeviceItem> mAdapter;
    private OnFragmentInteractionListener mListener;
    private SerialSocket serialSocket;
    private TextView pluse;
    int pulseSensorData = 0;
    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        homeViewModel =
                new ViewModelProvider(this).get(HomeViewModel.class);

        binding = FragmentHomeBinding.inflate(inflater, container, false);
        View root = binding.getRoot();
        mListView = binding.listItem;
        scanDeviceBtn = binding.Search;
        pluse = binding.pluse;
        bTAdapter = BluetoothAdapter.getDefaultAdapter();
        mListView.setOnItemClickListener(this);
        deviceItemList = new ArrayList<DeviceItem>();
        scanDeviceBtn.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                IntentFilter filter = new IntentFilter(BluetoothDevice.ACTION_FOUND);
                if(isChecked){
                    scanDevice();
                }
                else{

                }
            }
        });

        HttpsTrustManager.allowAllSSL();
        return root;

    }
    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
    void stopScan(){
    }
    public void scanDevice(){
        Set<BluetoothDevice> pairedDevices = bTAdapter.getBondedDevices();
        if (pairedDevices.size() > 0) {
            for (BluetoothDevice device : pairedDevices) {
                DeviceItem newDevice= new DeviceItem(device.getName(),device.getAddress(),"false");
                deviceItemList.add(newDevice);
            }
        }
        mAdapter = new DeviceListAdapter(getActivity(), deviceItemList, bTAdapter);
        mListView.setAdapter(mAdapter);
    }

    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

        Log.d("DEVICELIST", "onItemClick position: " + position +
                    " id: " + id + " name: " + deviceItemList.get(position).getDeviceName() + "\n");
        BluetoothDevice bluetoothDevice = bTAdapter.getRemoteDevice(deviceItemList.get(position).getAddress());
        serialSocket = new SerialSocket(getActivity().getApplicationContext(), bluetoothDevice);
        try {
            serialSocket.connect(this);
            serialSocket.run();
        } catch (IOException e) {
            e.printStackTrace();
        }
        if (null != mListener) {
            // Notify the active callbacks interface (the activity, if the
            // fragment is attached to one) that an item has been selected.
            mListener.onFragmentInteraction(deviceItemList.get(position).getDeviceName());
        }

    }

    @Override
    public void onAttach(Activity activity) {
        super.onAttach(activity);
        try {
            mListener = (OnFragmentInteractionListener) activity;
        } catch (ClassCastException e) {
            throw new ClassCastException(activity.toString()
                    + " must implement OnFragmentInteractionListener");
        }
    }

    @Override
    public void onDetach() {
        super.onDetach();
        mListener = null;
    }

    @Override
    public void onSerialConnect() {

    }

    @Override
    public void onSerialConnectError(Exception e) {

    }

    @Override
    public void onSerialRead(byte[] data) {
        String msg = new String(data);
        String intArray[];
        intArray = msg.split("\r\n");
        int sum = 0;
        int count = intArray.length;
        for(int i = 0; i< intArray.length; i++){
            int element = Integer.parseInt(intArray[i]);
            if(element > 0){
                sum += element;
            }
            else count = count - 1;
        }
        if(sum > 0 && count > 0){
            pulseSensorData = (int)sum / count;
            Log.d("data", String.valueOf(pulseSensorData));
        }
        pluse.setText(Integer.toString(pulseSensorData));
        sendPluse(pulseSensorData);
    }

    @Override
    public void onSerialIoError(Exception e) {

    }

    public interface OnFragmentInteractionListener {
        // TODO: Update argument type and name
        public void onFragmentInteraction(String id);
    }

    void sendPluse(int pluse){
        SharedPreferences editor = getContext().getSharedPreferences("USER_DATA", MODE_PRIVATE);
        String sessionId = editor.getString("UserId", null);
        JSONObject jsonArray = new JSONObject();
        try {
            jsonArray.put("UserID",sessionId);
            jsonArray.put("HeartBeat", pluse);
            jsonArray.put("CreatedBy", "Hải Dương 3724");
        } catch (JSONException e) {
            e.printStackTrace();
        }
        String mRequestBody = jsonArray.toString();
        String url = "https://iotandapp.eddieonthecode.xyz/api/v1/Meansure"; ;
        RequestQueue queue = Volley.newRequestQueue(getContext());
        StringRequest stringRequest = new StringRequest(Request.Method.POST, url,
                new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        Log.d("add", response);
                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.d("ERROR", error.toString());
            }
        }){
            @Override
            public byte[] getBody() throws AuthFailureError {
                try {
                    return mRequestBody == null ? null : mRequestBody.getBytes("utf-8");
                } catch (UnsupportedEncodingException e) {
                    e.printStackTrace();
                    return null;
                }
            }
            @Override
            public String getBodyContentType() {
                return "application/json; charset=utf-8";
            }
        };
        queue.add(stringRequest);
    }
}