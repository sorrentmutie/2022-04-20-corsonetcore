using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HelloIdentity.Models;

public static class GestioneUtenti
{

    public async static Task<IdentityResult> CreaRuolo(RoleManager<IdentityRole> roleManager,  string ruolo)
    {
        bool esisteRuolo = 
            await roleManager.RoleExistsAsync(ruolo);

        if(!esisteRuolo)
        {
            var nuovoRuolo = new IdentityRole
            {
                Name = ruolo
            };
            return await roleManager.CreateAsync(nuovoRuolo);
        } else
        {
            return null;
        }
    }

    public async static Task AggiungiClaimAUnUtente(UserManager<IdentityUser> userManager, string email)
    {
        var user = await userManager.FindByNameAsync(email);    
        if(user != null)
        {
            var claim = new Claim(ClaimTypes.MobilePhone, "938573579834578934");
            await userManager.AddClaimAsync(user, claim);
            var claim2 = new Claim("Matricola", "1234");
            await userManager.AddClaimAsync(user, claim2);
            
        }
    }



    public async static Task<IdentityResult> AssegnaRuoloAdUtente(UserManager<IdentityUser> userManager, string utente, string ruolo)
    {
        IdentityUser Utente = await userManager.FindByEmailAsync(utente);
            
        if(Utente != null)
        {
            return await userManager.AddToRoleAsync(Utente, ruolo);
        } else
        {
            var nuovoUtente = new IdentityUser
            {
                Email = utente,
                UserName = utente
            };
            var result = await userManager.CreateAsync(nuovoUtente, "EsempioPassword1!");
            if(result.Succeeded)
            {
                return await userManager.AddToRoleAsync(nuovoUtente, ruolo);
            }
            return null;
        }

    }


}
