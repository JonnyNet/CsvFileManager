import { CsvFileDTO } from "./csv-file-dto";

export interface CsvFilesStore {
  loading: boolean,
  fileCollection: {
    data: CsvFileDTO[],
    page: number,
    pageSize: number,
    total: number,
    totalPages: number,
  },
  items: {
    id: number,
    data: any[],
    total: number,
  },
};