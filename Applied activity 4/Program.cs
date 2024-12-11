using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Runtime.InteropServices;

class Program
{
   
    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("kernel32.dll")]
    private static extern IntPtr GetConsoleWindow();

    static void Main(string[] args)
    {
        
        ChromeOptions options = new ChromeOptions();
        options.AddArguments("--ignore-certificate-errors");       // Used to avoid any chrome certificate errors

        IWebDriver driver = new ChromeDriver(options);

        try                                                        // Login test begins
        {

            driver.Navigate().GoToUrl("https://www.netflix.com/login");

            // This is just used to set cmd in the foregroud
            IntPtr consoleWindowHandle = GetConsoleWindow();
            SetForegroundWindow(consoleWindowHandle);


            Console.WriteLine("\nEnter your email:\n");
            string? email = Console.ReadLine();
            Console.WriteLine("\nEnter your password:\n");
            string? password = Console.ReadLine();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("\n\nEmail and password cannot be empty.\n\n");
                return;
            }

            driver.FindElement(By.Name("userLoginId")).SendKeys(email);
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.XPath("//button[@data-uia='login-submit-button']")).Click();

            // Waiting
            System.Threading.Thread.Sleep(3000);


            try
            {
                // Checking if profile selection is visible
                IWebElement profileSelection = driver.FindElement(By.XPath("//ul[@class='choose-profile']"));
                if (profileSelection.Displayed)
                {
                    Console.WriteLine("\n\nLogin Test Successful.\n\n");
                }
            }
            catch (NoSuchElementException)
            {
                try
                {
                    IWebElement errorMessage = driver.FindElement(By.ClassName("ui-message-contents"));
                    Console.WriteLine($"\n\nLogin Test Failed: Cannot proceed with the next test\n\n");
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("\n\nLogin Test Failed: Cannot proceed with the next test\n");
                }

                return;                                                 // Login test ends

               

            }

            // Profile Selection test begins
            try

            {
                IWebElement firstProfile = driver.FindElement(By.XPath("//ul[@class='choose-profile']/li[1]//a"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", firstProfile);
                Console.WriteLine("\n\nProfile selection successful.\n\n");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("\n\nProfile selection failed: Cannot proceed with the next test\n\n");
                return;
            }

            // Profile Selection test ends

            // Throw  final exception 

        catch (Exception ex)
        {
             Console.WriteLine($"\n\nTest encountered an error: {ex.Message}\n\n");
        }
        }
        finally
        {
            driver.Quit();
        }

        }
}
