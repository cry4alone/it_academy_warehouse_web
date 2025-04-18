import React, { useState, useEffect } from 'react';
import './style.scss';
import { fetchLabels } from '@/pages/PrintPage/api/fetchLabel';
import { Label } from "../../types/printTypes";
import BtnArrowRight from './arrows/btnArrowRight/BtnArrowRight';
import BtnArrowLeft from './arrows/btnArrowLeft/BtnArrowLeft';

const LabelExample = () => {
  const [labels, setLabels] = useState<Label[]>([]); 
  const [currentLabelIndex, setCurrentLabelIndex] = useState<number>(0); 
  const [svgContent, setSvgContent] = useState<string>(''); 
  const [isLoading, setIsLoading] = useState<boolean>(true);

  useEffect(() => {
    const loadLabels = async () => {
      try {
        const labelsData = await fetchLabels(); 
        setLabels(labelsData);

        if (labelsData.length > 0) {
          const firstLabelSvg = await fetchLabelSvg(labelsData[0].imageURL); 
          setSvgContent(firstLabelSvg);
        }

        setIsLoading(false);
      } catch (error) {
        console.error('Ошибка при загрузке этикеток:', error);
        setIsLoading(false);
      }
    };

    loadLabels();
  }, []);

  const fetchLabelSvg = async (url: string): Promise<string> => {
    const response = await fetch(url);
    return await response.text();
  };

  const handlePrevLabel = async () => {
    const newIndex = (currentLabelIndex - 1 + labels.length) % labels.length; 
    setCurrentLabelIndex(newIndex);
    const newSvg = await fetchLabelSvg(labels[newIndex].imageURL);
    setSvgContent(newSvg);
  };

  const handleNextLabel = async () => {
    const newIndex = (currentLabelIndex + 1) % labels.length; 
    setCurrentLabelIndex(newIndex);
    const newSvg = await fetchLabelSvg(labels[newIndex].imageURL);
    setSvgContent(newSvg);
  };

  return (
    <div className="label-container">
      <h3>Пример выбранных этикеток</h3>
      <div className="label-wrapper">
        <BtnArrowLeft onClick={handlePrevLabel} disabled={isLoading} />
        <div className="label-content">
          {isLoading ? (
            <p>Загрузка...</p>
          ) : (
            <div dangerouslySetInnerHTML={{ __html: svgContent }} />
          )}
        </div>
        <BtnArrowRight onClick={handleNextLabel} disabled={isLoading} />
      </div>
    </div>
  );
};

export default LabelExample;