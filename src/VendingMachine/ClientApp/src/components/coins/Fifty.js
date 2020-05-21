import React from "react";
import CoinWrapper from "./CoinWrapper";

const Fifty = (props) => {
  return (
    <CoinWrapper onClick={props.onClick.bind(this, 0.5)}>0.50€</CoinWrapper>
  );
};

export default Fifty;
