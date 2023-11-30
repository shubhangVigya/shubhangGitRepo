package pageObject;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.ExpectedConditions;

import pageObject.AbstractComponent.AbstractComponent;

public class CheckoutPage extends AbstractComponent{
	
WebDriver driver;
	
	public CheckoutPage(WebDriver driver)
	{
		super(driver);
		this.driver = driver;
		PageFactory.initElements(driver, this);
		
		
	}
	
	@FindBy(css="[placeholder='Select Country']")
	WebElement Country;
	
	@FindBy(xpath="(//button[@type='button'])[2]")
	WebElement selectCountry;
	///button[contains(@class,'ta-item')])[2]
	
	@FindBy(css=".action__submit")
	WebElement submit;
	
	By results = By.cssSelector(".ta-results");
	
	public void SelectCountry( String CountryName)
	{
		Actions a = new Actions(driver);
		a.sendKeys(Country, CountryName).build().perform();
		
		waitforElementToAppear(results);
		
		selectCountry.click();
		
	
				
		
	}
	
	public ConfirmationPage Submit()
	{
		submit.click();
		return new ConfirmationPage(driver);
	}

}
