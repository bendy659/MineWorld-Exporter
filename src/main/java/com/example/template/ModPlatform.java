package com.example.template;


/**
 * This interface allows you to define platform specific code, and call it in 
 */

public interface ModPlatform {
    String getModloader();
    boolean isModLoaded(String modloader);
}
