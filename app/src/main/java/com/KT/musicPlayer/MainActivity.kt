package com.made_by_aasho_or_aka.musicPlayer

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.made_by_aasho_or_aka.musicPlayer.databinding.ActivityMainBinding

class MainActivity : AppCompatActivity() {
    //view binding
    private lateinit var binding:ActivityMainBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding =ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)
        //handle click,login

        binding.loginBtn.setOnClickListener{
            //will do it later
            startActivity(Intent(this, LoginActivity::class.java))
        }
        binding.skipBtn.setOnClickListener {

            //will do it later

            startActivity(Intent(this,StartActivity::class.java))
        }
    }
}