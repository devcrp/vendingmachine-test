import React from "react";
import { Card, CardBody, Button } from "reactstrap";
import Two from "./coins/Two";
import One from "./coins/One";
import Fifty from "./coins/Fifty";
import Twenty from "./coins/Twenty";
import Ten from "./coins/Ten";
import Five from "./coins/Five";
import CoinWrapper from "./coins/CoinWrapper";

const UserPanel = (props) => {
  const { onWalletAmountChanges, message, walletAmount, changeCoins } = props;

  const coinInsertedHandler = (value) => {
    fetch("api/wallet", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: value,
    }).then(async (res) => {
      if (res.ok) {
        const amount = Number.parseFloat(await res.text());
        onWalletAmountChanges(amount);
      }
    });
  };

  const returnCoinsHandler = () => {
    fetch("api/wallet", {
      method: "DELETE",
      headers: {
        "Content-Type": "application/json",
      },
    }).then(async (res) => {
      if (res.ok) {
        const amount = Number.parseFloat(await res.text());
        onWalletAmountChanges(amount);
      }
    });
  };

  return (
    <>
      <Card>
        <CardBody className="text-center">
          <div>AMOUNT: {walletAmount.toFixed(2)} €</div>
          {message.text.length > 0 && (
            <div className={"mt-2 text-uppercase text-" + message.variant}>
              {message.text}
            </div>
          )}
          {changeCoins.length > 0 && (
            <div
              className="d-flex mt-2 align-items-center"
              style={{ overflowX: "auto" }}
            >
              <span>your change coins: </span>
              {changeCoins.map((coin, idx) => (
                <CoinWrapper key={idx}>{coin.toFixed(2)}</CoinWrapper>
              ))}
            </div>
          )}
        </CardBody>
      </Card>
      <div className="d-flex mt-4 justify-content-end align-items-center">
        <span className="text-white">INSERT COIN: </span>
        <Two onClick={coinInsertedHandler}></Two>
        <One onClick={coinInsertedHandler}></One>
        <Fifty onClick={coinInsertedHandler}></Fifty>
        <Twenty onClick={coinInsertedHandler}></Twenty>
        <Ten onClick={coinInsertedHandler}></Ten>
        <Five onClick={coinInsertedHandler}></Five>
      </div>
      <div className="mt-4">
        <Button
          color="danger"
          size="lg"
          className="w-100"
          onClick={returnCoinsHandler}
        >
          RETURN COINS
        </Button>
      </div>
    </>
  );
};

export default UserPanel;
