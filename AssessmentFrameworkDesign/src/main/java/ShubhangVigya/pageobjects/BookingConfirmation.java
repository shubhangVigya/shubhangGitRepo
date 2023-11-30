package ShubhangVigya.pageobjects;

import org.openqa.selenium.WebDriver;

public class BookingConfirmation extends BasePage {
	
	WebDriver driver;
	
	
	
	
	public BookingConfirmation(WebDriver driver)
	{
		//initialization
		super(driver);
		this.driver = driver;// Gives life to driver in parent class
		
	}
	
	
	public String getFacilityText()
	{
		String facility = bookFacilityEle.getText(); //Extract Booked facility text
		
		return facility;
		
	
	}
	public String getProgramText()
	{
		
		String program = bookProgramEle.getText(); //Extract Booked program text
		return program;
	}
	
	
}
