import { Button, Col, Input, Pagination, Row, Select, Spin } from 'antd';
import React, { useContext, useEffect, useState } from 'react'
import { useHistory } from 'react-router';
import Notification from '../../common/components/Notification';
import { AppContext } from '../../context';
import { useLoading } from '../../Hooks/useLoading';
import { usePagination } from '../../Hooks/usePagination';
import ResultApi from '../../services/ResultApi';
import MyResultTable from './MyResultTable';

export default function MyResult() {
  const [data, setData] = useState([]);
  const [filter, setFilter] = useState({
    testName: undefined
  })
  const [loading, showLoading, hideLoading] = useLoading();
  const [paging, setPaging, onPageChange] = usePagination(onSearch, 15);
  let history = useHistory();
  const context = useContext(AppContext)

  useEffect(() => {
    onSearch();
  }, [])

  async function onSearch(currentPage = 1, pageSize = 15) {
    showLoading();
    // var submitFilter = { ...filter };
    // submitFilter.paging = {
    //   currentPage,
    //   pageSize
    // }
    var account = context.userInfo?.account;
    var res = await ResultApi.getResultsByAccount(account);
    if (res) {
      if (res.status === 200 && res.data) {
        var list = res.data;
        // var startNumber = newPaging.pageSize * (newPaging.currentPage - 1) + 1;
        // list.forEach(c => c.stt = startNumber++);
        // setPaging(newPaging);
        setData(list);
      }
      else {
        Notification.error(res.message);
      }
    }
    hideLoading();
  };

  return (
    <>
      <Spin spinning={loading}>
        <div className="page-content">
          <div style={{ padding: 20 }}>
            <MyResultTable data={data} />
            <div className="page-div">
              {/* <Pagination
                showSizeChanger
                showTotal={(total, range) => range[0] + ' - ' + range[1] + ' of ' + total + ' items'}
                onChange={onPageChange}
                defaultCurrent={1}
                total={paging.rowsCount}
                pageSizeOptions={['15', '20', '30', '40']}
                defaultPageSize={15}
              /> */}
            </div>
          </div>
        </div>
      </Spin>
    </>
  )
}
