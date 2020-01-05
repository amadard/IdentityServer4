﻿using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.ResponseHandling
{
    internal static class DataTypes
    {
        public const string String = "string";
        public const string Number = "number";
        public const string Integer = "integer";
        public const string Boolean = "boolean";
        public const string Array = "array";
        public const string Object = "object";
    }

    /// <summary>
    /// Default implementation of the swagger gen response generator
    /// </summary>
    /// <seealso cref="IdentityServer4.ResponseHandling.ISwaggerGenResponseGenerator" />
    public class SwaggerGenResponseGenerator : ISwaggerGenResponseGenerator
    {
        /// <summary>
        /// Creates an OpenApiDocument for Swagger
        /// </summary>
        /// <param name="issuerUri">Base URI for IdentityServer</param>
        public virtual Task<OpenApiDocument> CreateSwaggerDocAsync(string issuerUri)
        {
            var doc = new OpenApiDocument
            {
                Info = new OpenApiInfo
                {
                    Version = "v1",
                    Title = "IdentityServer4",
                    Description = "IdentityServer4 is an OpenID Connect and OAuth 2.0 framework for ASP.NET Core.",

                },
                Components = new OpenApiComponents()
                {
                    Schemas = new Dictionary<string, OpenApiSchema>
                    {
                        ["DiscoveryDocument"] = DiscoveryDocumentSchema(),
                    }
                },
                Servers = new List<OpenApiServer>
                {
                    new OpenApiServer { Url = issuerUri }
                },
                Paths = new OpenApiPaths
                {
                    ["/.well-known/openid-configuration"] = DiscoveryEndpointPathItem(),
                    ["/connect/authorize"] = AuthorizeEndpointPathItem(),
                    ["/connect/token"] = TokenEndpointPathItem(),
                    ["/connect/userinfo"] = UserInfoEndpointPathItem(),
                    ["/connect/deviceauthorization"] = DeviceAuthorizationEndpointPathItem(),
                    ["/connect/introspect"] = IntrospectionEndpointPathItem(),
                    ["/connect/revocation"] = RevocationEndpointPathItem(),
                    ["/connect/endsession"] = EndSessionEndpointPathItem(),
                    ["/connect/checksession"] = CheckSessionEndpointPathItem(),
                    //DiscoveryWebKeys ??
                }
            };

            return Task.FromResult(doc);
        }
        /// <summary>
        /// Returns the <see cref="OpenApiSchema" /> for the Discovery Endpoint
        /// </summary>
        public virtual OpenApiSchema DiscoveryDocumentSchema()
        {
            return new OpenApiSchema()
            {
                Type = DataTypes.Object,
                AdditionalPropertiesAllowed = true,
                Required = new HashSet<string>()
                {
                    "issuer",
                    "subject_types_supported",
                    "code_challenge_methods_supported"
                },
                Properties = new Dictionary<string, OpenApiSchema>()
                {
                    ["issuer"] = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    ["jwks_uri"] = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    ["authorization_endpoint"] = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    ["token_endpoint"] = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    ["userinfo_endpoint"] = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    ["end_session_endpoint"] = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    ["check_session_iframe"] = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    ["revocation_endpoint"] = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    ["introspection_endpoint"] = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    ["device_authorization_endpoint"] = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    ["mtls_endpoint_aliases"] = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    ["frontchannel_logout_supported"] = new OpenApiSchema()
                    {
                        Type = DataTypes.Boolean,
                    },
                    ["frontchannel_logout_session_supported"] = new OpenApiSchema()
                    {
                        Type = DataTypes.Boolean,
                    },
                    ["backchannel_logout_supported"] = new OpenApiSchema()
                    {
                        Type = DataTypes.Boolean,
                    },
                    ["backchannel_logout_session_supported"] = new OpenApiSchema()
                    {
                        Type = DataTypes.Boolean,
                    },
                    ["request_parameter_supported"] = new OpenApiSchema()
                    {
                        Type = DataTypes.Boolean,
                    },
                    ["request_uri_parameter_supported"] = new OpenApiSchema()
                    {
                        Type = DataTypes.Boolean,
                    },
                    ["tls_client_certificate_bound_access_tokens"] = new OpenApiSchema()
                    {
                        Type = DataTypes.Boolean,
                    },
                    ["scopes_supported"] = new OpenApiSchema()
                    {
                        UniqueItems = false,
                        Type = DataTypes.Array,
                        Items = new OpenApiSchema()
                        {
                            Type = DataTypes.String
                        }
                    },
                    ["claims_supported"] = new OpenApiSchema()
                    {
                        UniqueItems = false,
                        Type = DataTypes.Array,
                        Items = new OpenApiSchema()
                        {
                            Type = DataTypes.String
                        }
                    },
                    ["grant_types_supported"] = new OpenApiSchema()
                    {
                        UniqueItems = false,
                        Type = DataTypes.Array,
                        Items = new OpenApiSchema()
                        {
                            Type = DataTypes.String
                        }
                    },
                    ["response_types_supported"] = new OpenApiSchema()
                    {
                        UniqueItems = false,
                        Type = DataTypes.Array,
                        Items = new OpenApiSchema()
                        {
                            Type = DataTypes.String
                        }
                    },
                    ["response_modes_supported"] = new OpenApiSchema()
                    {
                        UniqueItems = false,
                        Type = DataTypes.Array,
                        Items = new OpenApiSchema()
                        {
                            Type = DataTypes.String
                        }
                    },
                    ["token_endpoint_auth_methods_supported"] = new OpenApiSchema()
                    {
                        UniqueItems = false,
                        Type = DataTypes.Array,
                        Items = new OpenApiSchema()
                        {
                            Type = DataTypes.String
                        }
                    },
                    ["id_token_signing_alg_values_supported"] = new OpenApiSchema()
                    {
                        UniqueItems = false,
                        Type = DataTypes.Array,
                        Items = new OpenApiSchema()
                        {
                            Type = DataTypes.String
                        }
                    },
                    ["subject_types_supported"] = new OpenApiSchema()
                    {
                        UniqueItems = false,
                        Type = DataTypes.Array,
                        Items = new OpenApiSchema()
                        {
                            Type = DataTypes.String
                        }
                    },
                    ["code_challenge_methods_supported"] = new OpenApiSchema()
                    {
                        UniqueItems = false,
                        Type = DataTypes.Array,
                        Items = new OpenApiSchema()
                        {
                            Type = DataTypes.String
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Returns the <see cref="OpenApiPathItem" /> for the Discovery Endpoint
        /// </summary>
        public virtual OpenApiPathItem DiscoveryEndpointPathItem()
        {
            return new OpenApiPathItem
            {
                Description = "The discovery endpoint can be used to retrieve metadata about your IdentityServer - it returns information like the issuer name, key material, supported scopes etc.",
                Operations = new Dictionary<OperationType, OpenApiOperation>
                {
                    [OperationType.Get] = new OpenApiOperation
                    {
                        Description = "Retrieve metadata about your IdentityServer",

                        ExternalDocs = new OpenApiExternalDocs()
                        {
                            Description = "Discovery Endpoint",
                            Url = new System.Uri("http://docs.identityserver.io/en/latest/endpoints/discovery.html")
                        },
                        Parameters = new List<OpenApiParameter>(),
                        Responses = new OpenApiResponses
                        {
                            ["200"] = new OpenApiResponse
                            {
                                Description = "OK",
                                Content = new Dictionary<string, OpenApiMediaType>()
                                {
                                    ["application/json"] = new OpenApiMediaType()
                                    {
                                        Example = new OpenApiString("{\"issuer\":\"https://demo.identityserver.io\",\"jwks_uri\":\"https://demo.identityserver.io/.well-known/openid-configuration/jwks\",\"authorization_endpoint\":\"https://demo.identityserver.io/connect/authorize\",\"token_endpoint\":\"https://demo.identityserver.io/connect/token\",\"userinfo_endpoint\":\"https://demo.identityserver.io/connect/userinfo\",\"end_session_endpoint\":\"https://demo.identityserver.io/connect/endsession\",\"check_session_iframe\":\"https://demo.identityserver.io/connect/checksession\",\"revocation_endpoint\":\"https://demo.identityserver.io/connect/revocation\",\"introspection_endpoint\":\"https://demo.identityserver.io/connect/introspect\",\"device_authorization_endpoint\":\"https://demo.identityserver.io/connect/deviceauthorization\",\"frontchannel_logout_supported\":true,\"frontchannel_logout_session_supported\":true,\"backchannel_logout_supported\":true,\"backchannel_logout_session_supported\":true,\"scopes_supported\":[\"openid\",\"profile\",\"email\",\"api\",\"policyserver.runtime\",\"policyserver.management\",\"offline_access\"],\"claims_supported\":[\"sub\",\"name\",\"family_name\",\"given_name\",\"middle_name\",\"nickname\",\"preferred_username\",\"profile\",\"picture\",\"website\",\"gender\",\"birthdate\",\"zoneinfo\",\"locale\",\"updated_at\",\"email\",\"email_verified\"],\"grant_types_supported\":[\"authorization_code\",\"client_credentials\",\"refresh_token\",\"implicit\",\"password\",\"urn:ietf:params:oauth:grant-type:device_code\"],\"response_types_supported\":[\"code\",\"token\",\"id_token\",\"id_token token\",\"code id_token\",\"code token\",\"code id_token token\"],\"response_modes_supported\":[\"form_post\",\"query\",\"fragment\"],\"token_endpoint_auth_methods_supported\":[\"client_secret_basic\",\"client_secret_post\"],\"id_token_signing_alg_values_supported\":[\"RS256\"],\"subject_types_supported\":[\"public\"],\"code_challenge_methods_supported\":[\"plain\",\"S256\"],\"request_parameter_supported\":true}"),
                                        Schema = new OpenApiSchema()
                                        {
                                            Reference = new OpenApiReference { Type = ReferenceType.Response, Id = "DiscoveryDocument" }
                                        }
                                    },
                                },
                            }
                        }
                    }
                }
            };
        }
        /// <summary>
        /// Returns the <see cref="OpenApiPathItem" /> for the Authorize Endpoint
        /// </summary>
        public virtual OpenApiPathItem AuthorizeEndpointPathItem()
        {
            var queryParameters = new List<OpenApiParameter>()
            {
                new OpenApiParameter()
                {
                    In = ParameterLocation.Query,
                    Name = "client_id",
                    Required = true,
                    Schema = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    Description = "identifier of the client",
                    AllowEmptyValue = false,
                },
                new OpenApiParameter()
                {
                    In = ParameterLocation.Query,
                    Name = "request",
                    Schema = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    Description = "instead of providing all parameters as individual query string parameters, you can provide a subset or all of them as a JWT",
                },
                new OpenApiParameter()
                {
                    In = ParameterLocation.Query,
                    Name = "request_uri",
                    Schema = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    Description = "URL of a pre-packaged JWT containing request parameters",
                },
                new OpenApiParameter()
                {
                    In = ParameterLocation.Query,
                    Name = "scope",
                    Required = true,
                    Schema = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    Description = "one or more registered scopes",
                    AllowEmptyValue = false,
                },
                new OpenApiParameter()
                {
                    In = ParameterLocation.Query,
                    Name = "redirect_uri",
                    Required = true,
                    Schema = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    Description = "must exactly match one of the allowed redirect URIs for that client",
                    AllowEmptyValue = false,
                },
                new OpenApiParameter()
                {
                    In = ParameterLocation.Query,
                    Name = "response_type",
                    Required = true,
                    Schema = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                        Enum = new List<IOpenApiAny>
                        {
                            new OpenApiString("id_token"),
                            new OpenApiString("token"),
                            new OpenApiString("id_token token"),
                            new OpenApiString("code"),
                            new OpenApiString("code id_token"),
                            new OpenApiString("code id_token token")
                        }
                    },
                    Description = "the response type: code, ideneity token and/or access token",
                },
                new OpenApiParameter()
                {
                    In = ParameterLocation.Query,
                    Name = "response_mode",
                    Required = false,
                    Schema = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                        Enum = new List<IOpenApiAny>
                        {
                            new OpenApiString("form_post"),
                        }
                    },
                    Description = "sends the token response as a form post instead of a fragment encoded redirect",
                },
                new OpenApiParameter()
                {
                    In = ParameterLocation.Query,
                    Name = "state",
                    Schema = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },                    
                    Description = "identityserver will echo back the state value on the token response, this is for round tripping state between client and provider, correlating request and response and CSRF/replay protection. (recommended)",
                },
                new OpenApiParameter()
                {
                    In = ParameterLocation.Query,
                    Name = "nonce",
                    Schema = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    Description = "identityserver will echo back the nonce value in the identity token, this is for replay protection. Required for identity tokens via implicit grant",
                },
                new OpenApiParameter()
                {
                    In = ParameterLocation.Query,
                    Name = "prompt",
                    Required = false,
                    Schema = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                        Enum = new List<IOpenApiAny>
                        {
                            new OpenApiString("none"),
                            new OpenApiString("login"),
                        }
                    },
                    Description = "the login UI will be shown or not",
                },
                new OpenApiParameter()
                {
                    In = ParameterLocation.Query,
                    Name = "code_challenge",
                    Schema = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    Description = "sends the code challenge for PKCE",
                },
                new OpenApiParameter()
                {
                    In = ParameterLocation.Query,
                    Name = "code_challenge_method",
                    Required = false,
                    Schema = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                        Enum = new List<IOpenApiAny>
                        {
                            new OpenApiString("plain"),
                            new OpenApiString("S256"),
                        }
                    },
                    Description = "plain indicates that the challenge is using plain text (not recommended) S256 indicates the challenge is hashed with SHA256",
                },
                new OpenApiParameter()
                {
                    In = ParameterLocation.Query,
                    Name = "login_hint",
                    Schema = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    Description = "can be used to pre-fill the username field on the login page",
                },
                new OpenApiParameter()
                {
                    In = ParameterLocation.Query,
                    Name = "ui_locales",
                    Schema = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    Description = "gives a hint about the desired display language of the login UI",
                },
                new OpenApiParameter()
                {
                    In = ParameterLocation.Query,
                    Name = "max_age",
                    Schema = new OpenApiSchema()
                    {
                        Type = DataTypes.String,
                    },
                    Description = "if the user’s logon session exceeds the max age (in seconds), the login UI will be shown",
                },
                new OpenApiParameter()
                {
                    In = ParameterLocation.Query,
                    Name = "acr_values",
                    Required = false,
                    Schema = new OpenApiSchema()
                    {
                        Type = DataTypes.Array,
                        Enum = new List<IOpenApiAny>
                        {
                            new OpenApiString("idp:name_of_idp"),
                            new OpenApiString("tenant:name_of_tenant "),
                        },
                        
                    },
                    Description = "allows passing in additional authentication related information - identityserver special cases the following proprietary acr_values:",
                },
            };

            var body = new OpenApiMediaType()
            {
                Schema = new OpenApiSchema()
                {
                    Properties = queryParameters.ToDictionary(k => k.Name,
                    v => new OpenApiSchema()
                    {
                        Type = v.Schema.Type,
                        Description = v.Description,
                        Enum = v.Schema.Enum,
                    }),
                    Required = queryParameters.Where(x => x.Required).Select(x => x.Name).ToHashSet()
                }
            };

            var responseExernalDoc = new OpenApiExternalDocs()
            {
                Description = "Authorize Endpoint",
                Url = new System.Uri("http://docs.identityserver.io/en/latest/endpoints/authorize.html")
            };
            var responseDescription = "Request tokens or authorization codes via the browser";

            //TODO - Reponses
            return new OpenApiPathItem
            {
                Description = "The authorize endpoint can be used to request tokens or authorization codes via the browser. This process typically involves authentication of the end-user and optionally consent.",
                Operations = new Dictionary<OperationType, OpenApiOperation>
                {
                    [OperationType.Get] = new OpenApiOperation
                    {
                        Description = responseDescription,
                        ExternalDocs = responseExernalDoc,
                        Parameters = queryParameters
                    },
                    [OperationType.Post] = new OpenApiOperation
                    {
                        Description = responseDescription,
                        ExternalDocs = responseExernalDoc,
                        RequestBody = new OpenApiRequestBody()
                        {
                            Content =
                            {
                                ["application/x-www-form-urlencoded"] = body,
                                ["multipart/form-data"] = body,
                            },
                        }
                    }
                }
            };
        }
        /// <summary>
        /// Returns the <see cref="OpenApiPathItem" /> for the Token Endpoint
        /// </summary>
        public virtual OpenApiPathItem TokenEndpointPathItem()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns the <see cref="OpenApiPathItem" /> for the UserInfo Endpoint
        /// </summary>
        public virtual OpenApiPathItem UserInfoEndpointPathItem()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns the <see cref="OpenApiPathItem" /> for the Device Authorization Endpoint
        /// </summary>
        public virtual OpenApiPathItem DeviceAuthorizationEndpointPathItem()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns the <see cref="OpenApiPathItem" /> for the Introspection Endpoint
        /// </summary>
        public virtual OpenApiPathItem IntrospectionEndpointPathItem()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns the <see cref="OpenApiPathItem" /> for the Revocation Endpoint
        /// </summary>
        public virtual OpenApiPathItem RevocationEndpointPathItem()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns the <see cref="OpenApiPathItem" /> for the End Session Endpoint
        /// </summary>
        public virtual OpenApiPathItem EndSessionEndpointPathItem()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns the <see cref="OpenApiPathItem" /> for the Check Session Endpoint
        /// </summary>
        public virtual OpenApiPathItem CheckSessionEndpointPathItem()
        {
            throw new NotImplementedException();
        }
    }
}
