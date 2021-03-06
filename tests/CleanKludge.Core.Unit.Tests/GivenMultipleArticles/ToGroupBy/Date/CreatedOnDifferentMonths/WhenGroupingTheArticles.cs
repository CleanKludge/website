﻿using System;
using System.Collections.Generic;
using CleanKludge.Api.Responses.Articles;
using CleanKludge.Core.Articles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanKludge.Core.Unit.Tests.GivenMultipleArticles.ToGroupBy.Date.CreatedOnDifferentMonths
{
    [TestClass]
    public class WhenGroupingTheArticles
    {
        private GroupedSummariesResponse _result;

        [TestInitialize]
        public void SetUp()
        {
            var articleSummaries = new List<ArticleSummary>
            {
                ArticleSummary.From(new ArticleDto { Created = new DateTimeOffset(new DateTime(2017, 01, 24, 08, 30, 55)), Title = "1" }),
                ArticleSummary.From(new ArticleDto { Created = new DateTimeOffset(new DateTime(2017, 02, 24, 08, 30, 55)), Title = "2" })
            };

            var subject = GroupedSummaries.From(articleSummaries, Grouping.Date);
            _result = subject.ToResponse();
        }

        [TestMethod]
        public void ThenTheArticlesAreGroupedByDate()
        {
            Assert.IsTrue(_result.GroupedBy == GroupedBy.Date);
        }

        [TestMethod]
        public void ThenThereAreTwoGroups()
        {
            Assert.IsTrue(_result.Groups[0].Count == 2);
        }

        [TestMethod]
        public void ThenThereIsOneRow()
        {
            Assert.IsTrue(_result.Groups.Count == 1);
        }

        [TestMethod]
        public void ThenThereIsAGroupForJanuary()
        {
            Assert.IsTrue(_result.Groups[0]["Jan 2017"].Count == 1);
        }

        [TestMethod]
        public void ThenThereIsAGroupForFebuary()
        {
            Assert.IsTrue(_result.Groups[0]["Feb 2017"].Count == 1);
        }
    }
}