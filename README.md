## Guide Launcher
A Windows utility developed to retrieve specific "Product Guides" from a network location.

### Purpose
The user types in a grade, or a full product number, and hits Enter.  
The utility quickly retrieves the related guides.  
Certain "grades" would have a secondary guide that needed to be referenced as well.  
A list of searched grades stays on the screen until the list is cleared or the utility is restarted.  

### Showcase
This professional project exemplifies:
* M-V-VM architecture with live data binding
* WPF UI with handcrafted XAML 

![screenshot](screenshot.png "Screenshot")

### Code Structure
* The main **View Model** is a [class called GuideScreen](ProductLauncher/VM/GuideScreen.cs) 
* All **View** items are bound to a class that is changed by the VM. For example:
  * The search bar is a [FormInput class](ProductLauncher/Data/FormInput.cs)
  * Each list item is a [Product class](ProductLauncher/Data/Product.cs)
* **Model** logic is called upon the above classes, or sometimes from the [static class ProductGuideLogic](ProductLauncher/Logic/ProductGuideLogic.cs)  



#### Notes
This project has been uploaded to serve as an example of **code structure**, it is *not meant to be executed*.  
Interpreted/compiled files and certain libraries have been removed for clutter.  
Addresses and names have been changed for security.  
