package com.example.iot.ui.home;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
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
import androidx.fragment.app.Fragment;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProvider;

import com.example.iot.R;
import com.example.iot.databinding.FragmentHomeBinding;
import com.example.iot.device.DeviceItem;

import java.util.ArrayList;
import java.util.Set;

public class HomeFragment extends Fragment {

    private static final int REQUEST_BLUETOOTH = 1;
    private HomeViewModel homeViewModel;
    private FragmentHomeBinding binding;
    private ListView listView;
    private ToggleButton scanDeviceBtn;
    BluetoothAdapter bTAdapter;
    private Set<BluetoothDevice> pairedDevices;
    ArrayList<DeviceItem>listDevices;
    private ArrayAdapter<DeviceItem> mAdapter;

    private final BroadcastReceiver bReciever = new BroadcastReceiver() {
        public void onReceive(Context context, Intent intent) {
            String action = intent.getAction();
            if (BluetoothDevice.ACTION_FOUND.equals(action)) {
                Log.d("DEVICELIST", "Bluetooth device found\n");
                BluetoothDevice device = intent.getParcelableExtra(BluetoothDevice.EXTRA_DEVICE);
                // Create a new device item
                DeviceItem newDevice = new DeviceItem(device.getName(), device.getAddress(), "false");
                // Add it to our adapter
                boolean isContain = false;
                for(DeviceItem dv : listDevices){
                    if(dv.getAddress().equals(device.getAddress())){
                        isContain = true;
                        break;
                    }
                }
                if(!isContain){
                    mAdapter.add(newDevice);
                    mAdapter.notifyDataSetChanged();
                }
            }
        }
    };
    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        homeViewModel =
                new ViewModelProvider(this).get(HomeViewModel.class);

        binding = FragmentHomeBinding.inflate(inflater, container, false);
        View root = binding.getRoot();
        listView = binding.listItem;
        scanDeviceBtn = binding.Search;
        bTAdapter = BluetoothAdapter.getDefaultAdapter();
        if (!bTAdapter.isEnabled()) {
            Intent enableBT = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
            startActivityForResult(enableBT, REQUEST_BLUETOOTH);
        }
        listDevices = new ArrayList<DeviceItem>();
        mAdapter = new ArrayAdapter(getContext(),android.R.layout.simple_list_item_1, listDevices);
        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Log.d("DEVICELIST", "onItemClick position: " + position +
                        " id: " + id + " name: " + listDevices.get(position).getDeviceName() + " address: "+ listDevices.get(position).getAddress()+ "\n"  );
            }
        });
        scanDeviceBtn.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                IntentFilter filter = new IntentFilter(BluetoothDevice.ACTION_FOUND);
                if(isChecked){
                    scanDevice();
                    getActivity().registerReceiver(bReciever, filter);
                    bTAdapter.startDiscovery();
                }
                else{
                    getActivity().unregisterReceiver(bReciever);
                    bTAdapter.cancelDiscovery();
                }
            }
        });
        return root;
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }

    void scanDevice(){
        pairedDevices = bTAdapter.getBondedDevices();
        for(BluetoothDevice device : pairedDevices){
            DeviceItem newDevice= new DeviceItem(device.getName(),device.getAddress(),"false");
            listDevices.add(newDevice);
        }
        Toast.makeText(getContext(),"Showing Paired Devices",Toast.LENGTH_SHORT).show();
        listView.setAdapter(mAdapter);
    }
    void stopScan(){
    }


}