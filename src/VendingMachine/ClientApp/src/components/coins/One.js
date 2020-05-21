import React from "react";
import CoinWrapper from "./CoinWrapper";

const One = (props) => {
  return <CoinWrapper onClick={props.onClick.bind(this, 1)}>1€</CoinWrapper>;
};

export default One;
