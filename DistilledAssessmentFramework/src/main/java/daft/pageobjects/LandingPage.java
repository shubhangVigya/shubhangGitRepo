package daft.pageobjects;

import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;

import daft.AbstractComponents.AbstractComponent;

public class LandingPage extends AbstractComponent {
	
	WebDriver driver;
	
	public LandingPage(WebDriver driver )
	{
		super(driver); //Initialize driver in parent class
		this.driver = driver; //Initialize driver from TestClass
		
		PageFactory.initElements(driver, this);
		
	}
	
	// Landing page Locators written in page factory design pattern
	
	@FindBy(id="didomi-notice-agree-button")
	WebElement agreeButton;
	
	By agreeButtonBy =  By.id("didomi-notice-agree-button");
	
	@FindBy(id="search-box-input")
	WebElement searchBar;
	
	// Hit Url
	public void goTo()
	{
		 driver.get("https://www.daft.ie/");
	}
	
	//Accept Privacy button
	public void acceptPrivacy()
	{
		waitForElementToAppear(agreeButtonBy);
		agreeButton.click();
	}
	
	//Populate County name and return next page as return type
	public BuyPage Search(String countyName)
	{
		searchBar.sendKeys(countyName);
		searchBar.sendKeys(Keys.ENTER);
		BuyPage buyPage = new BuyPage(driver);
		return buyPage;
		
	}
	
	

}
