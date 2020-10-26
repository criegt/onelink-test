import { Subarea } from './subarea';
export interface Area {
  areaId: number;
  name: string;
  subareas: Subarea[];
}
