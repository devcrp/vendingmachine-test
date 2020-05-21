import React, { useState, useEffect } from "react";
import { Row, Col, Container } from "reactstrap";
import ProductsGrid from "./ProductsGrid";
import UserPanel from "./UserPanel";

const VendingMachine = (props) => {
  const [products, setProducts] = useState([]);
  const [walletAmount, setWalletAmount] = useState(0);
  const [message, setMessage] = useState({ text: "" });
  const [changeCoins, setChangeCoins] = useState([]);

  const refreshPageData = () => {
    fetch("api/products").then(async (res) => {
      if (res.ok) {
        const result = await res.json();
        setProducts(result);
      }
    });
    fetch("api/wallet").then(async (res) => {
      if (res.ok) {
        const amount = Number.parseFloat(await res.text());
        setWalletAmount(amount);
      }
    });
  };

  useEffect(refreshPageData, []);

  const onWalletAmountChangesHandler = (amount) => {
    setWalletAmount(amount);
  };

  const onSelectProductHandler = (productId) => {
    fetch(`api/products/take/${productId}`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
    }).then(async (res) => {
      if (res.status === 400) {
        const msg = await res.text();
        setMessage({ variant: "danger", text: msg });
      } else if (res.ok) {
        let info = "";
        const coins = await res.json();

        const change = coins.reduce((a, b) => a + b, 0);
        if (change > 0) info = ` Your change is ${change.toFixed(2)}€`;

        setMessage({ variant: "success", text: "Thank you!" + info });
        setChangeCoins(coins);
        refreshPageData();
      }
    });
  };

  return (
    <Container style={{ height: "100vh" }} fluid>
      <Row style={{ height: "100vh" }}>
        <Col md="8" className="p-5">
          <ProductsGrid
            products={products}
            onSelectProduct={onSelectProductHandler}
          ></ProductsGrid>
        </Col>
        <Col md="4" className="p-5" style={{ backgroundColor: "#404a54" }}>
          <UserPanel
            onWalletAmountChanges={onWalletAmountChangesHandler}
            walletAmount={walletAmount}
            message={message}
            changeCoins={changeCoins}
          ></UserPanel>
        </Col>
      </Row>
    </Container>
  );
};

export default VendingMachine;
