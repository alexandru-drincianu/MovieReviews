import LinearProgress, { linearProgressClasses } from '@mui/material/LinearProgress';
import { styled } from "@mui/styles";

const LinearNoReviews = styled(LinearProgress)(({ theme }) => ({
    height: 15,
    width: 150,
    borderRadius: 5,
    [`&.${linearProgressClasses.colorPrimary}`]: {
      backgroundColor: '#DCD1C9',
    },
    [`& .${linearProgressClasses.bar}`]: {
      borderRadius: 5,
      backgroundColor: '#9F8069',
    },
  }));

export default LinearNoReviews;