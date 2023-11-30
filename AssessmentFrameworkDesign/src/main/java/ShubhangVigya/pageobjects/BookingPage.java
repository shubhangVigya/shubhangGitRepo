package ShubhangVigya.pageobjects;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.Select;

public class BookingPage extends BasePage {
	
	WebDriver driver;
	
	
	
	
	public BookingPage(WebDriver driver)
	{
		//initialization
		super(driver); // Gives life to driver in parent class
		this.driver = driver;
		
	}

	
	public BookingConfirmation bookingApplicationMedicare(String comment)
	{
		WebElement facilityOptions = facilityEle; // saves dropdown element into one object
		Select dropdown = new Select(facilityOptions); // using Select class created object "dropdown"
		
		dropdown.selectByIndex(2); // choose facility in dropdown using Select class method index value
		
		calendarEle.click();
		dateEle.click();// select desired date
		commentEle.sendKeys(comment);
		bookEle.click();
		BookingConfirmation bookingConfirmation = new BookingConfirmation(driver);//Create object for next expected page
		return bookingConfirmation;
	}
	public BookingConfirmation bookingApplicationMedicaid(String comment)
	{
		WebElement facilityOptions = facilityEle;
		Select dropdown = new Select(facilityOptions);
		
		dropdown.selectByIndex(2);
		progranmMedicaidEle.click();// select Medicaid Healthcare program radio button
		calendarEle.click();
		dateEle.click();
		commentEle.sendKeys(comment);
		bookEle.click();
		BookingConfirmation bookingConfirmation = new BookingConfirmation(driver);
		return bookingConfirmation;
	}
	public BookingConfirmation bookingApplicationNone(String comment)
	{
		WebElement facilityOptions = facilityEle;
		Select dropdown = new Select(facilityOptions);
		
		dropdown.selectByIndex(2);
		progranmNoneEle.click(); // select None Healthcare program radio button
		calendarEle.click();
		dateEle.click();
		commentEle.sendKeys(comment);
		bookEle.click();
		BookingConfirmation bookingConfirmation = new BookingConfirmation(driver);
		return bookingConfirmation;
	}
	
}
