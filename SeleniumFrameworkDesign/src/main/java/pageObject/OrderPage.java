package pageObject;

import java.util.List;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.testng.Assert;

import pageObject.AbstractComponent.AbstractComponent;

public class OrderPage extends AbstractComponent {
	
	WebDriver driver;
	
	public OrderPage(WebDriver driver)
	{
		super(driver);
		this.driver = driver;
		PageFactory.initElements(driver, this);
		
		
	}
	
	@FindBy(css=".cartSection h3")
	List<WebElement> cartProducts;
	
	@FindBy(css="tr td:nth-child(3)")
	List<WebElement> ProductNames;
	
	
	
	
	public Boolean VerifyOrderDisplay(String productName)
	{
		//List <WebElement> cartProducts = driver.findElements(By.cssSelector(".cartSection h3"));		
		Boolean match = 	ProductNames.stream().anyMatch(productNames-> productNames.getText().equalsIgnoreCase(productName));
		return match;
	}
		

}
