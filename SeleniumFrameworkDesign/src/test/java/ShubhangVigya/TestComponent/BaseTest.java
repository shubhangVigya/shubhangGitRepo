package ShubhangVigya.TestComponent;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.time.Duration;
import java.util.HashMap;
import java.util.List;
import java.util.Properties;

import org.apache.commons.io.FileUtils;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import java.nio.charset.StandardCharsets;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.apache.commons.io.FileUtils;


import pageObject.LandingPage;

public class BaseTest {
	
	public WebDriver driver;
	public LandingPage landingpage;
	
	public WebDriver initializeDriver() throws IOException
	{
		
		
		Properties prop = new Properties();
		FileInputStream fis  = new FileInputStream("//Users//shubhangvigya//Desktop//Java Workspace//SeleniumFrameworkDesign//src//main//java//resources//GlobalData.properties");
		prop.load(fis);
		
		String browserName = prop.getProperty("browser");
		
		
		
		if(browserName.equalsIgnoreCase("chrome"))
		{
			
		 driver = new ChromeDriver();
		
		}
		else if (browserName.equalsIgnoreCase("firefox"))
		{
			// Firefox code
		}
		else if (browserName.equalsIgnoreCase("edge"))
		{
			// edge code
		}
		driver.manage().timeouts().implicitlyWait(Duration.ofSeconds(10));
		driver.manage().window().maximize();
		return driver;
	}
		
		

//	public List<HashMap<String, String>> getJsonDataToMap(String filePath) throws IOException
//	{
//		//read json to string
//	String jsonContent = 	FileUtils.readFileToString(new File(filePath), 
//			StandardCharsets.UTF_8);
//	
//	//String to HashMap- Jackson Databind
//	
//	ObjectMapper mapper = new ObjectMapper();
//	  List<HashMap<String, String>> data = mapper.readValue(jsonContent, new TypeReference<List<HashMap<String, String>>>() {
//      });
//	  return data;
//	
//	//{map, map}
//
//	}
		
		
		
	
	
	@BeforeMethod
	public LandingPage launchApplication() throws IOException
	{
		driver = initializeDriver();
		 landingpage = new LandingPage(driver); 

		 landingpage.goTo();
		 return landingpage;
		 
		
	}
	
	@AfterMethod
	public void teardown()
	{
		driver.close();
	}
	

}
