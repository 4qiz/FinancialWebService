import React from "react";
import Table from "../../Components/Table/Table";
import RatioList from "../../Components/RatioList/RatioList";
import {
  TestDataCompany,
  testIncomeStatementData,
} from "../../Components/Table/testData";

type Props = {};

//const data = TestDataCompany;

const tableConfig = [
  {
    label: "symbol",
    render: (company: any) => company.symbol,
  },
];

const DesignPage = (props: Props) => {
  return (
    <>
      <h1>FinShark Design page</h1>
      <h2>
        This is FinShark's Design page. This is where we will house various
        Design aspects of the app.
      </h2>
      <RatioList data={testIncomeStatementData} config={tableConfig} />
      <Table data={testIncomeStatementData} config={tableConfig} />
    </>
  );
};

export default DesignPage;
