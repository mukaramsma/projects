import React, { useState } from "react";
import { Form, Card, InputGroup, Button } from "react-bootstrap";
import { SummaryFilter } from "./../Models/Filter";

export interface SalesSummaryActionsParameters {
  OnSelectionChanged: (summaryFilter: SummaryFilter) => void;
}

const SalesSummaryActions: React.FC<SalesSummaryActionsParameters> = ({
  OnSelectionChanged,
}) => {
  const [year, setYear] = useState<string>("2020");
  const [locationType, setLocationType] = useState<number>(1);

  return (
    <Card className="p-3 m-3">
      <Form.Group controlId="selectYear">
        <Form.Control
          type="year"
          name="dob"
          placeholder="Enter Year"
          value={year}
          onChange={(event) => setYear(event.currentTarget.value)}
        />
      </Form.Group>
      <Form.Group>
        <Form.Check
          inline
          type="radio"
          label="Country"
          name="location"
          onClick={() => setLocationType(0)}
        />
        <Form.Check
          inline
          defaultChecked
          type="radio"
          label="State"
          name="location"
          onClick={() => setLocationType(1)}
        />
        <Form.Check
          inline
          type="radio"
          label="City"
          name="location"
          onClick={() => setLocationType(2)}
        />
      </Form.Group>
      <Form.Group>
        <Button
          className="float-right"
          variant="dark"
          onClick={() =>
            OnSelectionChanged({ Year: year, LocationType: locationType })
          }
        >
          Apply
        </Button>
      </Form.Group>
    </Card>
  );
};

export default SalesSummaryActions;
