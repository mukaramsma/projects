import React, { ReactElement, useState } from "react";
import { Form, Card, InputGroup, Button } from "react-bootstrap";
import { SaleInfo } from "./../Models/SaleInfo";

export interface NewSalesSummaryParameters {
  OnChanged: (saleInfo: SaleInfo) => void;
}

const NewSalesSummary: React.FC<NewSalesSummaryParameters> = ({
  OnChanged,
}) => {
  const [saleInfo, setSaleInfo] = useState<SaleInfo>({
    Date: undefined,
    Country: undefined,
    State: undefined,
    City: undefined,
    TotalValue: 0,
  });

  return (
    <Form>
      <Form.Group>
        <Form.Label>Country</Form.Label>
        <Form.Control
          type="text"
          onChange={(event) => {
            saleInfo.Country = event.currentTarget.value;
            setSaleInfo(saleInfo);
            OnChanged(saleInfo);
          }}
        />
      </Form.Group>
      <Form.Group>
        <Form.Label>State</Form.Label>
        <Form.Control
          type="text"
          onChange={(event) => {
            saleInfo.State = event.currentTarget.value;
            setSaleInfo(saleInfo);
            OnChanged(saleInfo);
          }}
        />
      </Form.Group>
      <Form.Group>
        <Form.Label>City</Form.Label>
        <Form.Control
          type="text"
          onChange={(event) => {
            saleInfo.City = event.currentTarget.value;
            setSaleInfo(saleInfo);
            OnChanged(saleInfo);
          }}
        />
      </Form.Group>
      <Form.Group>
        <Form.Label>Month</Form.Label>
        <Form.Control
          type="month"
          onChange={(event) => {
            saleInfo.Date = event.currentTarget.value;
            setSaleInfo(saleInfo);
            OnChanged(saleInfo);
          }}
        />
      </Form.Group>
      <Form.Group>
        <Form.Label>Total Sales</Form.Label>
        <Form.Control
          type="text"
          onChange={(event) => {
            saleInfo.TotalValue = parseInt(event.currentTarget.value);
            setSaleInfo(saleInfo);
            OnChanged(saleInfo);
          }}
        />
      </Form.Group>
    </Form>
  );
};

export default NewSalesSummary;
