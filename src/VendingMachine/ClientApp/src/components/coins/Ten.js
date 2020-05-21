import React from "react";
import CoinWrapper from "./CoinWrapper";

const Ten = (props) => {
  return (
    <CoinWrapper onClick={props.onClick.bind(this, 0.1)}>0.10€</CoinWrapper>
  );
};

export default Ten;
