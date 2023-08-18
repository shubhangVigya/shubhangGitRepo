import java.time.Duration;
import java.util.List;
import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.Select;
import org.openqa.selenium.support.ui.WebDriverWait;

public class loginPage {

	@SuppressWarnings("deprecation")
	public static void main(String[] args) {
		
		
		WebDriver driver = new ChromeDriver();
		
		driver.manage().timeouts().implicitlyWait( 5, TimeUnit.SECONDS);
		
		driver.get("https://rahulshettyacademy.com/loginpagePractise/");
		driver.findElement(By.id("username")).sendKeys("rahulshettyacademy");
		driver.findElement(By.id("password")).sendKeys("learning");
		driver.findElement(By.xpath("(//label[@class='customradio'])[2]")).click();
		
		// Explicit wait time
		WebDriverWait wait = new WebDriverWait(driver, Duration.ofMillis(7000));

		wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("okayBtn")));
		
		driver.findElement(By.id("okayBtn")).click();
		
		
		WebElement drop = driver.findElement(By.cssSelector("select[class='form-control']"));
		Select dropdown = new Select(drop);
		dropdown.selectByIndex(2);
		
		
		driver.findElement(By.id("terms")).click();
		driver.findElement(By.id("signInBtn")).click();
		
		//Explicit wait time

		wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("signInBtn")));
		
		List<WebElement> Cart = driver.findElements(By.xpath("//button[@class='btn btn-info']"));
		
	
		
		for(int i = 0; i<Cart.size(); i++ )
		{
		
		Cart.get(i).click();
		}
		driver.findElement(By.cssSelector("a.nav-link.btn.btn-primary")).click();
		
		
		
		
		
		
		

	}

}
