package pageObject;


import java.util.List;

import org.openqa.selenium.By;
import org.openqa.selenium.SearchContext;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.ExpectedConditions;

import pageObject.AbstractComponent.AbstractComponent;

public class ProductCatalogue extends AbstractComponent{
	
	WebDriver driver;
	
	public ProductCatalogue(WebDriver driver)
	{
		super(driver);
		this.driver = driver;
		PageFactory.initElements(driver, this);
		
		
	}
	
	// List of all products
	
	@FindBy(css=".mb-3")
	List<WebElement> products;
	@FindBy(css=".ng-animating")
	WebElement Spinner;
	
	By productBy = By.cssSelector(".mb-3");
	By AddtoCart = By.cssSelector(".card-body button:last-of-type");
	By toastMessage = By.cssSelector("#toast-container");
	
	//Return Product List into Method
	public List<WebElement> ProductList()
	{
		waitforElementToAppear(productBy);
		return products;
	}
	
	public  WebElement GetProductByName(String productName)
	{
		
		WebElement prod =	products.stream().filter(product->
		product.findElement(By.cssSelector("b")).getText().equals(productName)).findFirst().orElse(null);
		return prod;
		
		
	}
	
	public void addProductToCart(String productName) // When this Method will be called this is what it expect
	{
		WebElement prod = GetProductByName(productName);
		prod.findElement(AddtoCart).click();
		waitforElementToAppear(toastMessage);
		waitforElementToDisAppear(Spinner);
	
		
	}


}
 