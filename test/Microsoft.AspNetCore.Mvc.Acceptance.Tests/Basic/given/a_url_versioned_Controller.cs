﻿namespace given
{
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Basic;
    using Microsoft.AspNetCore.Mvc.Basic.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;
    using static System.Net.HttpStatusCode;

    public class _a_url_versioned_Controller : BasicAcceptanceTest
    {
        [Theory]
        [InlineData( "api/v1/helloworld", null )]
        [InlineData( "api/v1/helloworld/42", "42" )]
        public async Task _get_should_return_200( string requestUrl, string id )
        {
            // arrange
            var body = new Dictionary<string, string>()
            {
                ["controller"] = nameof( HelloWorldController ),
                ["version"] = "1"
            };

            if ( !string.IsNullOrEmpty( id ) )
            {
                body["id"] = id;
            }

            // act
            var response = await GetAsync( requestUrl ).EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsAsync<IDictionary<string, string>>();

            // assert
            response.Headers.GetValues( "api-supported-versions" ).Single().Should().Be( "1.0" );
            content.ShouldBeEquivalentTo( body );
        }

        [Fact]
        public async Task _post_should_return_201()
        {
            // arrange
            var entity = default( object );

            // act
            var response = await PostAsync( "api/v1/helloworld", entity ).EnsureSuccessStatusCode();

            // assert
            response.Headers.Location.Should().Be( new Uri( "http://localhost/api/v1/HelloWorld/42" ) );
        }

        [Fact]
        public async Task _get_should_return_400_when_version_is_unsupported()
        {
            // arrange


            // act
            var response = await GetAsync( "api/v2/helloworld" );
            var content = await response.Content.ReadAsAsync<OneApiErrorResponse>();

            // assert
            response.StatusCode.Should().Be( BadRequest );
            content.Error.Code.Should().Be( "UnsupportedApiVersion" );
        }
    }
}