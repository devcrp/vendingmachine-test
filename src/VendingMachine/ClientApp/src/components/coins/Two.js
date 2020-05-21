import React from "react";
import CoinWrapper from "./CoinWrapper";

const Two = (props) => {
  return <CoinWrapper onClick={props.onClick.bind(this, 2)}>2€</CoinWrapper>;
};

export default Two;
