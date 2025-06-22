package com.made_by_aasho_or_aka.musicPlayer

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.made_by_aasho_or_aka.musicPlayer.databinding.ActivityAboutBinding

class AboutActivity : AppCompatActivity() {

    lateinit var binding: ActivityAboutBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setTheme(StartActivity.currentThemeNav[StartActivity.themeIndex])
        binding = ActivityAboutBinding.inflate(layoutInflater)
        setContentView(binding.root)
        supportActionBar?.title = "About"
        binding.aboutText.text = aboutText()
    }
    private fun aboutText(): String{
        return "Developed By: Kamrul ,Anan, Arafat" +
                "\n\nIf you want to provide feedback, we will love to hear that."
    }
}