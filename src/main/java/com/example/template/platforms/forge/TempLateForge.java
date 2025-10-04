//? if forge {
/*package com.example.template.platforms.forge;

import com.example.template.ConfigScreen;
import com.example.template.TempLateInit;
import com.example.template.ModPlatform;
import net.minecraftforge.common.MinecraftForge;
import net.minecraftforge.fml.ModList;
import net.minecraftforge.fml.common.Mod;

@Mod("template")
public class TempLateForge {
	public TempLateForge() {
		TempLateInit.entrypoint(new ForgePlatform());
        MinecraftForge.registerConfigScreen(ConfigScreen::createConfigScreen);
	}
	public static class ForgePlatform implements ModPlatform {
		@Override
		public String getModloader() {
			return "LexForge";
		}

		@Override
		public boolean isModLoaded(String modId) {
			return ModList.get().isLoaded(modId);
		}
	}

}
*///?}