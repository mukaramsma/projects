import { SummaryFilter } from "./../Models/Filter";
import { SaleInfo } from "./../Models/SaleInfo";

export const SalesSummaryUrl = `http://localhost:58590/api/salessummary`;

export const FetchSalesSummary = (
  filter: SummaryFilter,
  onDataReceived: (data: any) => void,
  onError: (error: any) => void
) => {
  fetch(
    `${SalesSummaryUrl}?Year=${filter.Year}&LocationType=${filter.LocationType}`,
    {
      method: "GET",
      headers: {
        Accept: "application/json",
      },
    }
  )
    .then((res) => res.json())
    .then(onDataReceived)
    .catch(onError);
};

export const AddNewSalesSummary = (
  saleInfo: SaleInfo,
  onAdded: () => void,
  onError: (error: any) => void
) => {
  fetch(SalesSummaryUrl, {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      SaleDate: saleInfo.Date,
      Country: saleInfo.Country,
      State: saleInfo.State,
      City: saleInfo.City,
      TotalSales: saleInfo.TotalValue,
    }),
  })
    .then(onAdded)
    .catch(onError);
};
