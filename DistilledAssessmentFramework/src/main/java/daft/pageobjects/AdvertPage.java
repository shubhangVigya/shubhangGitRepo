package daft.pageobjects;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;

import daft.AbstractComponents.AbstractComponent;

public class AdvertPage extends AbstractComponent {

	WebDriver driver;

	public AdvertPage(WebDriver driver) {

		super(driver); // Initialize driver in parent class
		this.driver = driver; // Initialize driver from TestClass

		// Advert page Locators written in page factory design pattern
		PageFactory.initElements(driver, this);

	}

	@FindBy(xpath = "//div[@class='styles__StandardParagraph-sc-15fxapi-8 eMCuSm']")
	WebElement descriptionEle;

	// scan for Keyword text from description
	public String wordScan() {
		String text = descriptionEle.getText();

		return text;
	}

}
