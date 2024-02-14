package daftIeTests;

import java.io.IOException;
import java.util.HashMap;

import org.testng.annotations.DataProvider;

public class DataFile {
	
	@DataProvider
	public Object [] [] getData() throws IOException
	{
		// inputs data as a key pair value into object "map" that can be called in @test
		HashMap <String,String> map = new HashMap<String,String>();
		map.put("County", "Dublin");
		map.put("Keyword", "garage");
		return new Object [][] {{map}};
	}

}
