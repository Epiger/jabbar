package com.none.helloworld;

import javax.swing.JWindow;

import com.sun.glass.ui.Size;

public class HelloWorld {

    public static main(string[] args){
        System.out.println("HelloWorld");

        JWindow window = new JWindow();
        
        window.setPreferredSize(new Size(300, 400));
        window.setVisible(true);
        
    }

}