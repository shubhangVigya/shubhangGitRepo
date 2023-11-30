package ShubhangVigya;

import java.io.IOException;

import org.testng.Assert;
import org.testng.AssertJUnit;
import org.testng.annotations.Test;

import ShubhangVigya.TestComponent.BaseTest;
import pageObject.CartPage;
import pageObject.ProductCatalogue;



public class ErrorValidationsTest extends BaseTest {
	//public static void main(String[] args) {

	@Test(groups= {"Error Handing"})
	public void loginErrorValidation() throws IOException , InterruptedException
	{ 
 landingpage.loginApplication("anshika@gmail.com", "Iamking@000");
	AssertJUnit.assertEquals("Incorrect email or password.", landingpage.getErrorMessage());	
	
	}
	
	@Test
	public void submitOrder() throws IOException , InterruptedException
	{
	String productName = "ZARA COAT 3";

	
	
 
	landingpage.loginApplication("anshika@gmail.com", "Iamking@000");
	ProductCatalogue productCatalogue = new ProductCatalogue(driver);

	productCatalogue.ProductList();
	productCatalogue.addProductToCart(productName);
	CartPage cartPage = productCatalogue.goToCart();
	
		Boolean match = cartPage.VerifyProductDisplay("ZARA COAT 33");
	Assert.assertTrue(match);

}
}
