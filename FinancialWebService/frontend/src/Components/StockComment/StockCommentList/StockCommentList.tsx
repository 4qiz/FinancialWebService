import React from "react";
import { CommentGet } from "../../../Models/Comment";
import StockCommentItem from "../StockCommentItem/StockCommentItem";

type Props = {
  comments: CommentGet[];
};

const StockCommentList = ({ comments }: Props) => {
  return (
    <>
      {comments
        ? comments.map((comment) => {
            return <StockCommentItem comment={comment} />;
          })
        : ""}
    </>
  );
};

export default StockCommentList;
