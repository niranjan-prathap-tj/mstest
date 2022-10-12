﻿// <copyright file="BuildAdapter_GenerateBuildStatusUrl_Should.cs" company="Automate The Planet Ltd.">
// Copyright 2016 Automate The Planet Ltd.
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>http://automatetheplanet.com/</site>
using System;
using JenkinsCSharpApi.Infrastructure;
using JenkinsCSharpApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JenkinsCSharpApi.UnitTests.BuildAdapterTests
{
    [TestClass]
    public class BuildAdapter_GenerateBuildStatusUrl_Should
    {
        [TestMethod]
        public void GenerateBuildStatusUrl()
        {
            var buildAdapter = new BuildAdapter(new HttpAdapter(), JenkinsTestData.JenkinsUrl, JenkinsTestData.ProjectName);
            string resutedUrl = buildAdapter.GenerateBuildStatusUrl(JenkinsTestData.JenkinsUrl, JenkinsTestData.ProjectName);

            Assert.AreEqual<string>(
                @"http://localhost:8080/job/Jenkins-CSharp-Api.Parameterized/api/xml",
                resutedUrl,
                "The Build status Url was not created correctly.");
        }

        [TestMethod]
        [ExpectedException(exceptionType: typeof(ArgumentException), noExceptionMessage: "The Argument exception was not throwed in case of incorrect Build status Url")]
        public void ThrowArgumentException_WhenIncorrectUrlIsBuilt()
        {
            string jenkunsServerUrl = " &^s";
            string projectName = "#";
            var buildAdapter = new BuildAdapter(new HttpAdapter());

            buildAdapter.GenerateBuildStatusUrl(jenkunsServerUrl, projectName);
        }
    }
}