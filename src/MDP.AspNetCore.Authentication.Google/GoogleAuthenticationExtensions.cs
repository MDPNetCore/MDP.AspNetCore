﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MDP.AspNetCore.Authentication.Google
{
    public static class GoogleAuthenticationExtensions
    {
        // Methods
        public static AuthenticationBuilder AddGoogleAuthentication(this IServiceCollection services, GoogleAuthenticationSetting authenticationSetting = null)
        {
            #region Contracts

            if (services == null) throw new ArgumentException($"{nameof(services)}=null");
         
            #endregion

            // AuthenticationSetting
            if (authenticationSetting == null) authenticationSetting = new GoogleAuthenticationSetting();
            if (string.IsNullOrEmpty(authenticationSetting.ClientId) == true) throw new InvalidOperationException($"{nameof(authenticationSetting.ClientId)}=null");
            if (string.IsNullOrEmpty(authenticationSetting.ClientSecret) == true) throw new InvalidOperationException($"{nameof(authenticationSetting.ClientSecret)}=null");

            // AuthenticationBuilder   
            var authenticationBuilder = services.AddAuthentication();

            // Google
            authenticationBuilder.AddGoogle(options =>
            {
                // Options
                options.ClientId = authenticationSetting.ClientId;
                options.ClientSecret = authenticationSetting.ClientSecret;
                options.AccessType = "offline";
                options.SaveTokens = true;

                // SignIn
                options.SignInPath("/.auth/signin");
                options.SignInScheme = RemoteAuthenticationDefaults.AuthenticationScheme;
            });

            // Return
            return authenticationBuilder;
        }
    }
}
