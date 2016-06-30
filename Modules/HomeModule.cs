using Nancy;
using System.Collections.Generic;
using Tamagotchi.Objects;

namespace Tamagotchi
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get ["/"] = _ => View ["pet_form.cshtml"];
      Post ["/pets"] = _ => {
        Pet newPet = new Pet
        (
        Request.Form["petName"]
        );
        return View ["pet.cshtml", newPet];
      };
      Post ["/pet/feed"] = _ => {
        List<Pet> list = Pet.GetAll();
        Pet currentPet = list[0];
        currentPet.FeedPet();
        return View ["pet.cshtml", currentPet];
      };
      Post ["/pet/play"] = _ => {
        List<Pet> list = Pet.GetAll();
        Pet currentPet = list[0];
        currentPet.PlayWithPet();
        return View ["pet.cshtml", currentPet];
      };
      Post ["/pet/sleep"] = _ => {
        List<Pet> list = Pet.GetAll();
        Pet currentPet = list[0];
        currentPet.GivePetSleep();
        return View ["pet.cshtml", currentPet];
      };
      Post ["/pet/time"] = _ => {
        List<Pet> list = Pet.GetAll();
        Pet currentPet = list[0];
        currentPet.MakeTimePass();
        return View ["pet.cshtml", currentPet];
      };
    }
  }
}
