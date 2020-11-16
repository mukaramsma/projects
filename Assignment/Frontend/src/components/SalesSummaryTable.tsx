import React, { useEffect, useState } from "react";
import * as ReactBootStrap from "react-bootstrap";

export interface SalesSummaryTableParameters {
  salesData: any;
  byMonth: boolean;
}

const SalesSummaryTable: React.FC<SalesSummaryTableParameters> = ({
  salesData,
  byMonth,
}) => {
  const [salesSummary, setSalesSummary] = useState<any>([]);
  const [locations, setLocations] = useState<any>([]);
  const [time, setTime] = useState<any>([]);
  const months = [
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December",
  ];
  useEffect(() => {
    if (!salesData) return;

    let timeArray = new Array();
    setSalesSummary(salesData);
    setLocations(salesData.map((x: any) => x.location));
    salesData.map((x: any) => {
      timeArray = timeArray.concat(x.salesDatas.map((d: any) => d.duration));
    });
    setTime(Array.from(new Set(timeArray)).sort());
  }, [salesData]);

  var index = 0;
  return (
    <ReactBootStrap.Card className="p-3 m-3">
      <ReactBootStrap.Table striped bordered hover size="sm" responsive>
        <thead>
          <tr key={index++}>
            <th></th>
            {locations.map((location: any) => (
              <th>{location ?? "Unknown"}</th>
            ))}
          </tr>
        </thead>
        <tbody>
          {time.map((time: any) => (
            <tr key={index++}>
              <th>{byMonth ? months[time - 1] : time}</th>
              {salesSummary.map((sale: any) => (
                <td>
                  {sale.salesDatas.find((x: any) => x.duration === time)
                    ?.value ?? "---"}
                </td>
              ))}
            </tr>
          ))}
          <tr style={{ height: "30px" }} key={index++} />
          <tr key={index++}>
            <th>Avg.</th>
            {salesSummary.map((sale: any) => (
              <th>{sale.average}</th>
            ))}
          </tr>
          <tr key={index++}>
            <th>Med.</th>
            {salesSummary.map((sale: any) => (
              <th>{sale.median}</th>
            ))}
          </tr>
          <tr key={index++}>
            <th>Total.</th>
            {salesSummary.map((sale: any) => (
              <th>{sale.sum}</th>
            ))}
          </tr>
        </tbody>
      </ReactBootStrap.Table>
    </ReactBootStrap.Card>
  );
};

export default SalesSummaryTable;
