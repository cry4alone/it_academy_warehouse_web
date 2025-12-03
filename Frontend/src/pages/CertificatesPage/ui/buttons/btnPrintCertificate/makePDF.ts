// import jsPDF from 'jspdf';
// import { ICertificateData } from '../../../types/certificateTypes';
// import { font } from "@shared/fonts/custom-font"

// export const makePDF = (data: any[]) => {
//     const doc = new jsPDF();

//     try {
//         //todo не работает с кириллицей

//         // doc.addFileToVFS("CustomFont.ttf", font);
//         // doc.addFont("CustomFont.ttf", "CustomFont", "normal");
//         // doc.setFont("CustomFont");
      
//         // doc.setFontSize(20);

//         // data.forEach((item, index) => {
//         //     doc.text(`Сертификат №: ${item.certificateNumber}`, 10, 10 + (index * 60));
//         //     doc.text(`Схема контроля: ${item.controlScheme}`, 10, 20 + (index * 60));
//         //     doc.text(`Дата: ${item.date}`, 10, 30 + (index * 60));
//         //     doc.text(`Склад: ${item.warehouse}`, 10, 40 + (index * 60));
//         //     doc.text(`Подписант: ${item.signatory}`, 10, 50 + (index * 60));
//         //     doc.text(`Количество позиций: ${item.countPosition}`, 10, 60 + (index * 60));
//         // });

//         // doc.save('certificate.pdf');
//     } catch (error) {
//         console.error('Error generating PDF:', error);
//     }
// };

