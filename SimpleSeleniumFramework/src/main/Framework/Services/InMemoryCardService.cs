using SimpleSeleniumFramework.src.main.Common.Constants;
using SimpleSeleniumFramework.src.main.Common.Interfaces;
using SimpleSeleniumFramework.src.main.Framework.Models;
using System;

namespace SimpleSeleniumFramework.src.main.Framework.Services
{
    public class InMemoryCardService : ICardService
    {
        public ICard GetCardByName(string cardName)
        {
            switch (cardName)
            {
                case Card.ELEMENTS:
                    return new ElementsCard();

                case Card.FORMS:
                    return new FormsCard();

                case Card.ALERTS_FRAME_WINDOWS:
                    return new AlertsFrameWindowsCard();

                case Card.WIDGETS:
                    return new WidgetsCard();

                case Card.INTERACTIONS:
                    return new InteractionsCard();

                case Card.BOOKSTORE:
                    return new BookStoreCard();

                default:
                    throw new ArgumentException($"{cardName} is not available.");
            }
        }
    }
}
