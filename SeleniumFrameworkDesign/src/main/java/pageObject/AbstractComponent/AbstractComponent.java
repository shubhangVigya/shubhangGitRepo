package pageObject.AbstractComponent;

import java.time.Duration;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import pageObject.CartPage;
import pageObject.OrderPage;

public class AbstractComponent {

	
	// Add utilities here that can be utilized
	
	
	WebDriver driver;
	public AbstractComponent(WebDriver driver) {
		this.driver = driver;
		PageFactory.initElements(driver, this);
	}
	
	@FindBy(css="[routerlink*='cart']")
	WebElement cartHeader;
	
	@FindBy(css="[routerlink*='myorders']")
	WebElement orderHeader;


	
	public void waitforElementToAppear(By findBY)
	{
	WebDriverWait wait = new WebDriverWait(driver,Duration.ofSeconds(5));
	wait.until(ExpectedConditions.visibilityOfElementLocated((findBY)));
	}
	
	public void waitforElementToAppear(WebElement findBY)
	{
	WebDriverWait wait = new WebDriverWait(driver,Duration.ofSeconds(5));
	wait.until(ExpectedConditions.visibilityOf((findBY)));
	}
	
	
	public void waitforElementToDisAppear(WebElement ele)
	{
		
		WebDriverWait wait = new WebDriverWait(driver,Duration.ofSeconds(5));
		wait.until(ExpectedConditions.invisibilityOf(ele));
	}
	
	public CartPage goToCart()
	{
		 cartHeader.click();
		 CartPage cartPage = new CartPage(driver);
		 return cartPage;
	}
	public OrderPage goToOrderPage()
	{
		 orderHeader.click();
		 OrderPage 	orderPage = new OrderPage(driver);
		 return orderPage;
	}
}
