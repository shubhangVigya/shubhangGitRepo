package ShubhangVigya.testcase;

import java.io.IOException;
import java.util.HashMap;

import org.testng.annotations.DataProvider;

public class DataFile {
	
	@DataProvider
	public Object [] [] getData() throws IOException
	{
		// inputs data as a key pair value into object "map" that can be called in @test
		HashMap <String,String> map = new HashMap<String,String>();
		map.put("userName", "John Doe");
		map.put("password", "ThisIsNotAPassword");
		map.put("comment", "I want to book my yearly check-up.");
		return new Object [][] {{map}};
	}

}
