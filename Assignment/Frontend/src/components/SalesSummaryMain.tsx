import React, { ReactElement, useEffect, useState } from "react";
import SalesSummaryActions from "./SalesSummaryActions";
import SalesSummaryTable from "./SalesSummaryTable";
import { Container, Row, Col, Button, Modal } from "react-bootstrap";
import NewSalesSummary from "./NewSaleSummary";
import { SummaryFilter } from "./../Models/Filter";
import { SaleInfo } from "./../Models/SaleInfo";
import { AddNewSalesSummary } from "./../Helpers/Util";
import { FetchSalesSummary } from "./../Helpers/Util";

function SalesSummaryMain(): ReactElement {
  const [summaryFilter, setSummaryFilter] = useState<SummaryFilter>({
    Year: "2020",
    LocationType: 1,
  });
  const [newSaleInfo, setNewSaleInfo] = useState<SaleInfo>();
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleSave = () => {
    setShow(false);
    if (newSaleInfo)
      AddNewSalesSummary(newSaleInfo, fetchSalesInfo, (error) => alert(error));
  };

  const [salesData, setSalesData] = useState<any>();
  const fetchSalesInfo = () => {
    FetchSalesSummary(summaryFilter, setSalesData, alert);
  };

  useEffect(() => {
    fetchSalesInfo();
  }, [summaryFilter]);
  return (
    <Container>
      <Row>
        <Col>
          <h3 style={{ margin: "10px" }}>XYZ - Cars Sales Summary</h3>
        </Col>
      </Row>
      <Row>
        <Col>
          <SalesSummaryActions OnSelectionChanged={setSummaryFilter} />
        </Col>
      </Row>
      <Row>
        <Col>
          <SalesSummaryTable
            salesData={salesData}
            byMonth={summaryFilter.Year !== "0"}
          />
        </Col>
      </Row>
      <Row>
        <Col>
          <Button
            className="float-right m-3"
            variant="dark"
            onClick={() => setShow(true)}
          >
            Add New Sales Info
          </Button>
        </Col>
      </Row>
      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>New Sales Info</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <NewSalesSummary OnChanged={setNewSaleInfo} />
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
          <Button variant="primary" onClick={handleSave}>
            Save
          </Button>
        </Modal.Footer>
      </Modal>
    </Container>
  );
}

export default SalesSummaryMain;
