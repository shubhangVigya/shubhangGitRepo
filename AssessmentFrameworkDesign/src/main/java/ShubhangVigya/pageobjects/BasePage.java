package ShubhangVigya.pageobjects;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;

public class BasePage {
	
	WebDriver driver;

	public BasePage(WebDriver driver) {
		
		this.driver = driver;
		PageFactory.initElements(driver, this); //gives life to driver in Locators following page factory pattern
		
	}
	
	
	//Landing page Locators
	
	//PageFactory design Pattern
	@FindBy (id ="btn-make-appointment")
	WebElement appointment;
	
	//Login Page Locators
	
	@FindBy (id ="txt-username")
	WebElement userEmail;
	
	@FindBy (id ="txt-password")
	WebElement passwordEle;
	
	@FindBy (xpath = "//button[@id=\"btn-login\"]")
	WebElement login;
	
	//BookingPage Locators
	
	@FindBy (id ="combo_facility")
	WebElement facilityEle;
	
	@FindBy (id ="radio_program_medicaid")
	WebElement progranmMedicaidEle;
	
	@FindBy (id ="radio_program_none")
	WebElement progranmNoneEle;
		
	@FindBy (xpath ="//span[@class=\"glyphicon glyphicon-calendar\"]")
	WebElement calendarEle;
	
	@FindBy (xpath ="//td[text()='6' and @class='day']")
	WebElement dateEle;
	
	@FindBy (id ="txt_comment")
	WebElement commentEle;
	

	@FindBy (id ="btn-book-appointment")
	WebElement bookEle;
	
	
	// Booking Confirmation Locators
		
	@FindBy (id ="facility")
	WebElement bookFacilityEle;
		
	@FindBy (id ="program")
	WebElement bookProgramEle;
		

}
