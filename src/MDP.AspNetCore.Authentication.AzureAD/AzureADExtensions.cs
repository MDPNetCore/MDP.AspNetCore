﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MDP.AspNetCore.Authentication.AzureAD
{
    public static class AzureADExtensions
    {
        // Methods
        public static AuthenticationBuilder AddAzureAD(this AuthenticationBuilder builder)
        {
            #region Contracts

            if (builder == null) throw new ArgumentException(nameof(builder));

            #endregion

            // AddAzureAD
            return builder.AddAzureAD(_ => { });
        }

        public static AuthenticationBuilder AddAzureAD(this AuthenticationBuilder builder, Action<AzureADOptions> configureOptions)
        {
            #region Contracts

            if (builder == null) throw new ArgumentException(nameof(builder));
            if (configureOptions == null) throw new ArgumentException(nameof(configureOptions));

            #endregion

            // AddAzureAD
            return builder.AddAzureAD(AzureADDefaults.AuthenticationScheme, configureOptions);
        }

        public static AuthenticationBuilder AddAzureAD(this AuthenticationBuilder builder, string authenticationScheme, Action<AzureADOptions> configureOptions)
        {
            #region Contracts

            if (builder == null) throw new ArgumentException(nameof(builder));
            if (string.IsNullOrEmpty(authenticationScheme) == true) throw new ArgumentException($"{nameof(authenticationScheme)}=null");
            if (configureOptions == null) throw new ArgumentException(nameof(configureOptions));

            #endregion

            // AddOAuth
            return builder.AddOAuth<AzureADOptions, AzureADHandler>(authenticationScheme, null, configureOptions);
        }
    }
}
