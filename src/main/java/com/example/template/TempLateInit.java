package com.example.template;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class TempLateInit
{
	public static final String MODID = "template";
	public static final Logger LOGGER = LoggerFactory.getLogger("Template");
	public static ModPlatform PLATFORM = null;

	public static void entrypoint(ModPlatform platform) {
		TempLateInit.PLATFORM = platform;
		LOGGER.info("Started mod in %s loader".formatted(TempLateInit.PLATFORM.getModloader()));
	}
}