import React, { useEffect, useState } from "react";
import { CompanyCompData } from "../../company";
import { getCompData } from "../../api";
import CompFinderItem from "./CompFinderItem";

type Props = {
  ticker: string;
};

const CompFinder = ({ ticker }: Props) => {
  const [companyData, setCompanyData] = useState<CompanyCompData>();
  useEffect(() => {
    const getComps = async () => {
      const val = await getCompData(ticker);
      setCompanyData(val?.data[0]);
    };
    getComps();
  }, [ticker]);
  return (
    <div className="inline-flex rounded-md shadow-sm m-4">
      {companyData?.peersList.map((ticker) => {
        return <CompFinderItem ticker={ticker} />;
      })}
    </div>
  );
};

export default CompFinder;
