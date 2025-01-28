<<<<<<< HEAD
import React from "react";
import Table from "../components/table/Table";
import { useAuth } from "../Context";

const Columns = [
  { key: "name", header: "Название товара" },
  { key: "date", header: "Дата" },
  { key: "count", header: "Количество" },
];

const data = [
  { name: "Товар 1", date: "01.01.2023", count: 10 },
  { name: "Товар 2", date: "02.01.2023", count: 20 },
  { name: "Товар 3", date: "03.01.2023", count: 30 },
];

function ReadyProduction() {
  const { user } = useAuth();
  return (
    <>
      {console.log(user)}
      <div style={{ marginTop: "10px" }}>Готовое производство</div>
      <Table columns={Columns} data={data} />
=======
import React, { useContext } from 'react';
import TableReadyProduction from '../components/table/TableReadyProduction';
import { Button } from 'antd';
import { ButtonContext } from '../contexts/ButtonContext';
import '../styles/global.scss';

function ReadyProduction() {
const { showAdditionalButtons } = useContext(ButtonContext);

return (
    <>
    <div className="tab__title">Готовое производство</div>
    <TableReadyProduction />
    <div className="button-container">
        {!showAdditionalButtons && (
        <>
            <Button>Перераспределить сертификат</Button>
            <Button>Возврат продукции</Button>
            <Button>Работа с сертификатами</Button>
            <Button>Печать этикеток</Button>
        </>
        )}
        {showAdditionalButtons && (
        <>
            <Button>Отмена</Button>
            <Button type="primary">Добавить пакеты</Button>
        </>
        )}
    </div>
>>>>>>> 78c94d6e93668807d0c55491bc45785a66493e04
    </>
);
}

<<<<<<< HEAD
export default ReadyProduction;
=======
export default ReadyProduction;
>>>>>>> 78c94d6e93668807d0c55491bc45785a66493e04
