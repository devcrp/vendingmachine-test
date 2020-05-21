import React from "react";
import CoinWrapper from "./CoinWrapper";

const Twenty = (props) => {
  return (
    <CoinWrapper onClick={props.onClick.bind(this, 0.2)}>0.20€</CoinWrapper>
  );
};

export default Twenty;
