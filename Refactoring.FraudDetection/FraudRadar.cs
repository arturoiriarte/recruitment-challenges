// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Refactoring.FraudDetection
{
    using Refactoring.FraudDetection.Models;
    using Refactoring.FraudDetection.Services;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FraudRadar
    {
        IOrderFileReader reader;
        IFraudService fraudService;
        public FraudRadar(IOrderFileReader reader, IFraudService fraudService)
        {
            this.reader = reader;
            this.fraudService = fraudService;
        }

        public IEnumerable<FraudResult> Check(FileStream fileStream)
        {
            
            var orders = reader.Read(fileStream).ToList();
            var fraudResults = fraudService.GetFrauds(orders);

            return fraudResults;
        }
    }
}