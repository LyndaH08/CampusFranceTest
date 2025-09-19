using CampusFrance.test.Functions;
using CampusFrance.test.ObjectClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;

namespace CampusFrance.test.TestCreateAccount
{
    [TestFixture]
    public class TesteChexkboxStudent
    {
        public IWebDriver driver;
        public IWebElement dropdownInput;
        public List<User> users;


        [SetUp]
        public void Setup()
        {
            //Instanciation 
            driver = new ChromeDriver();
            users = ReadDataFromJson.FromJsonFileToObject();
        }


        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }


        [Test]
        public void AccountStudentLicence1Sport()
        {
            driver.Navigate().GoToUrl("https://www.campusfrance.org/fr/user/register");

            //Renseigner les champs de saisie du formulaire
            //Informations de connexion
            driver.FindElement(By.XPath("//input[@placeholder='monadresse@domaine.com']")).SendKeys(users[0].AdresseMail);
            driver.FindElement(By.CssSelector("#edit-pass-pass1")).SendKeys(users[0].MotDePasse);
            driver.FindElement(By.CssSelector("#edit-pass-pass2")).SendKeys(users[0].MotDePasse);


            //Informations personnelles
            driver.FindElement(By.Id("tarteaucitronPersonalize2")).Click(); // Accepter cookies                                                              
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true); arguments[0].click();",
                        driver.FindElement(By.Id("edit-field-civilite-mr")));
            driver.FindElement(By.Id("edit-field-nom-0-value")).SendKeys(users[0].Nom);
            driver.FindElement(By.Id("edit-field-prenom-0-value")).SendKeys(users[0].Prenom);

            //Selectionner le pays de résidence
            // C'est un Input et pas un Select = récupere l'element, vider le champ, taper le pays, et entrer
            dropdownInput = driver.FindElement(By.Id("edit-field-pays-concernes-selectized"));
            dropdownInput.SendKeys(Keys.Backspace);
            dropdownInput.SendKeys(users[0].PaysResidence);
            dropdownInput.SendKeys(Keys.Enter);


            driver.FindElement(By.Id("edit-field-nationalite-0-target-id")).SendKeys(users[0].PaysNationalite);
            driver.FindElement(By.Id("edit-field-code-postal-0-value")).SendKeys(users[0].Adresse.CodePostale);
            driver.FindElement(By.Id("edit-field-ville-0-value")).SendKeys(users[0].Adresse.Ville);
            driver.FindElement(By.Id("edit-field-telephone-0-value")).SendKeys(users[0].Telephone);

            //Informations complémentaire
            //Scroller  avant de cocher le bouton radio  Etudiant
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true); arguments[0].click();", 
                       driver.FindElement(By.Id("edit-field-publics-cibles-2")));


            // C'est un Input et pas un Select = récupere l'element, vider le champ, taper le pays, et entrer
            dropdownInput = driver.FindElement(By.Id("edit-field-domaine-etudes-selectized"));
            dropdownInput.SendKeys(Keys.Backspace);
            dropdownInput.SendKeys(users[0].Domaine);
            dropdownInput.SendKeys(Keys.Enter);

            dropdownInput = driver.FindElement(By.Id("edit-field-niveaux-etude-selectized"));
            dropdownInput.SendKeys(Keys.Backspace);
            dropdownInput.SendKeys(users[0].Niveau);
            dropdownInput.SendKeys(Keys.Enter);


            //driver.FindElement(By.XPath("//*[@id=\"edit-field-accepte-communications-value\"]")).Click();
            // Vérifier que le label du bouton de validation du formulaire
            Assert.AreEqual("Créer un compte", driver.FindElement(By.Id("edit-submit")).GetAttribute("value"));


            // Vérifier que le statut sélectionné est "Etudiant"
            Assert.IsTrue(driver.FindElement(By.Id("edit-field-publics-cibles-2")).Selected, "Le bouton 'Étudiant' n'est pas sélectionné.");

            // Vérifier que le niveau sélectionné est "Licence 1", recupere le text de l'item qui est le text selectionner
            Assert.AreEqual("Licence 1", driver.FindElement(By.CssSelector("#edit-field-niveaux-etude-wrapper > div > div > div.selectize-input.items.has-options.full.has-items > div")).Text);

         }


        [Test]
        public void AccountStudentDoctoratBiology()
        {
            driver.Navigate().GoToUrl("https://www.campusfrance.org/fr/user/register");

            //Renseigner les champs de saisie du formulaire
            //Informations de connexion
            driver.FindElement(By.XPath("//input[@placeholder='monadresse@domaine.com']")).SendKeys(users[1].AdresseMail);
            driver.FindElement(By.CssSelector("#edit-pass-pass1")).SendKeys(users[1].MotDePasse);
            driver.FindElement(By.CssSelector("#edit-pass-pass2")).SendKeys(users[1].MotDePasse);


            //Informations personnelles
            driver.FindElement(By.Id("tarteaucitronPersonalize2")).Click(); // Accepter cookies
            //Scroller puis Cocher la case MR
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true); arguments[0].click();",
                        driver.FindElement(By.Id("edit-field-civilite-mr")));
            driver.FindElement(By.Id("edit-field-nom-0-value")).SendKeys(users[1].Nom);
            driver.FindElement(By.Id("edit-field-prenom-0-value")).SendKeys(users[1].Prenom);

            //Selectionner le pays de résidence
            // C'est un Input et pas un Select = récupere l'element, vider le champ, taper le pays, et entrer
            dropdownInput = driver.FindElement(By.Id("edit-field-pays-concernes-selectized"));
            dropdownInput.SendKeys(Keys.Backspace);
            dropdownInput.SendKeys(users[1].PaysResidence);
            dropdownInput.SendKeys(Keys.Enter);


            driver.FindElement(By.Id("edit-field-nationalite-0-target-id")).SendKeys(users[1].PaysNationalite);
            driver.FindElement(By.Id("edit-field-code-postal-0-value")).SendKeys(users[1].Adresse.CodePostale);
            driver.FindElement(By.Id("edit-field-ville-0-value")).SendKeys(users[1].Adresse.Ville);
            driver.FindElement(By.Id("edit-field-telephone-0-value")).SendKeys(users[1].Telephone);

            //Informations complémentaire
            //Scroller  avant de cocher le bouton radio  Etudiant
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true); arguments[0].click();",
                       driver.FindElement(By.Id("edit-field-publics-cibles-2")));


            // C'est un Input et pas un Select = récupere l'element, vider le champ, taper le pays, et entrer
            dropdownInput = driver.FindElement(By.Id("edit-field-domaine-etudes-selectized"));
            dropdownInput.SendKeys(Keys.Backspace);
            dropdownInput.SendKeys(users[1].Domaine);
            dropdownInput.SendKeys(Keys.Enter);

            dropdownInput = driver.FindElement(By.Id("edit-field-niveaux-etude-selectized"));
            dropdownInput.SendKeys(Keys.Backspace);
            dropdownInput.SendKeys(users[1].Niveau);
            dropdownInput.SendKeys(Keys.Enter);


            //driver.FindElement(By.XPath("//*[@id=\"edit-field-accepte-communications-value\"]")).Click();
            // Vérifier que le label du bouton de validation du formulaire
            Assert.AreEqual("Créer un compte", driver.FindElement(By.Id("edit-submit")).GetAttribute("value"));


            // Vérifier que le statut sélectionné est "Etudiant"
            Assert.IsTrue(driver.FindElement(By.Id("edit-field-publics-cibles-2")).Selected, "Le bouton 'Étudiant' n'est pas sélectionné.");

            // Vérifier que le niveau sélectionné est "Licence 1", recupere le text de l'item qui est le text selectionner
            Assert.AreEqual("Doctorat / PhD", driver.FindElement(By.CssSelector("#edit-field-niveaux-etude-wrapper > div > div > div.selectize-input.items.has-options.full.has-items > div")).Text);
        }




       
    }
}