package com.example.iot;

import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import com.android.volley.AuthFailureError;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.iot.network.HttpsTrustManager;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.UnsupportedEncodingException;

public class LoginActivity extends AppCompatActivity {
    private Button loginBtn;
    private EditText mUsername, mPassword;
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.login_layout);
        loginBtn = findViewById(R.id.login_button);
        mUsername = findViewById(R.id.username);
        mPassword = findViewById((R.id.password));
        loginBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String userName = mUsername.getText().toString();
                String password = mPassword.getText().toString();
                HttpsTrustManager.allowAllSSL();
                JSONObject jsonArray = new JSONObject();
                try {
                    jsonArray.put("Name",userName);
                    jsonArray.put("Password", password);
                    jsonArray.put("Language", "VietNamese");
                } catch (JSONException e) {
                    e.printStackTrace();
                }
                Log.d("TAG", jsonArray.toString());
                String mRequestBody = jsonArray.toString();
                String url = "https://iotandapp.eddieonthecode.xyz/api/v1/Account/check-valid-account"; ;
                RequestQueue queue = Volley.newRequestQueue(getApplicationContext());
                StringRequest stringRequest = new StringRequest(Request.Method.POST, url,
                        new Response.Listener<String>() {
                            @Override
                            public void onResponse(String response) {
                                try {
                                    JSONObject responseJson = new JSONObject(response);
                                    String data = responseJson.getString("Data");
                                    String data2 = new JSONObject(data).getString("Data");
                                    JSONObject userInfo = new JSONObject(data2);
                                    String seessionId = userInfo.getString("SessionID");
                                    String userId = userInfo.getString("UserID");
                                    SharedPreferences.Editor editor = getSharedPreferences("USER_DATA", MODE_PRIVATE).edit();
                                    editor.putString("SessionID", seessionId);
                                    editor.putString("UserId", userId);
                                    editor.apply();
                                    Toast.makeText(getApplicationContext(), "Login Successfull",
                                            Toast.LENGTH_SHORT).show();
                                    finish();
                                } catch (JSONException e) {
                                    Toast.makeText(getApplicationContext(), "Login Fail", Toast.LENGTH_SHORT).show();
                                    e.printStackTrace();
                                }
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
        });
    }
}
